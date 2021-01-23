    //This helper class to use some Win32 functions, must add using System.Runtime.InteropServices;
    public class Win32 {
        [DllImport("user32")]
        public static extern bool GetCaretPos(out POINT pos);
        [DllImport("user32")]
        public static extern bool SetCaretPos(int x, int y);
        [DllImport("user32")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        public struct POINT {
            public int x, y;
        }
    }
    //This is the extension class for TextBox, it's just for convenience
    public static class TextBoxExtension {
        public static void BeginUpdate(this TextBox text) {
            Win32.SendMessage(text.Handle, 0xb, IntPtr.Zero, IntPtr.Zero);
        }
        public static void EndUpdate(this TextBox text) {
            Win32.SendMessage(text.Handle, 0xb, new IntPtr(1), IntPtr.Zero);
        }
        public static int GetCaretCharIndex(this TextBox text){
            Win32.POINT p;
            Win32.GetCaretPos(out p);
            return text.GetCharIndexFromPosition(new Point(p.x, p.y));
        }
        public static void SetCaretCharIndex(this TextBox text, int charIndex) {
            Point p = text.GetPositionFromCharIndex(charIndex);
            Win32.SetCaretPos(p.X, p.Y);
        }
        public static void ProcessRight(this TextBox text, bool shiftPressed) {
            if (shiftPressed) {
                int lastEndIndex = text.SelectionStart + text.SelectionLength;
                int caretCharIndex = text.GetCaretCharIndex();
                if (caretCharIndex == lastEndIndex || (caretCharIndex == text.TextLength-1 && text.SelectionLength > 1)){
                    text.SelectionLength++;                    
                } else {
                    text.BeginUpdate();
                    text.SelectionStart++;                    
                    if (lastEndIndex < text.TextLength) text.SelectionLength--;
                    text.EndUpdate();
                    text.Refresh();
                    if (text.SelectionStart < text.TextLength) text.SetCaretCharIndex(text.SelectionStart);
                } 
            } else {
                if (text.SelectionLength > 0) {
                    int s = text.SelectionLength;
                    text.SelectionLength = 0;
                    text.SelectionStart += s;
                }
                else if (text.SelectionStart < text.TextLength) text.SelectionStart++; 
            }
        }
        public static void ProcessLeft(this TextBox text, bool shiftPressed) {
            if (shiftPressed) {
                if (text.GetCaretCharIndex() == text.SelectionStart || text.SelectionStart == text.TextLength) {
                    if (text.SelectionStart > 0) {
                        text.BeginUpdate();
                        text.SelectionStart--;
                        text.SelectionLength++;                                                                        
                        text.EndUpdate();
                        text.Refresh();
                        text.SetCaretCharIndex(text.SelectionStart);
                    }
                } else {
                    text.SelectionLength--;
                }
            } else {
                if (text.SelectionStart > 0 && text.SelectionLength == 0) text.SelectionStart--;
                text.SelectionLength = 0;
            }
        }
        public static void ProcessHome(this TextBox text, bool shiftPressed) {
            if (shiftPressed) {
                int i = text.SelectionStart;
                text.SelectionStart = 0;
                text.SelectionLength = i;
                text.SetCaretCharIndex(0);
            } else {
                text.SelectionLength = 0;
                text.SelectionStart = 0;
            }
        }
        public static void ProcessEnd(this TextBox text, bool shiftPressed) {
            if (shiftPressed) {
                text.SelectionLength = text.TextLength - text.SelectionStart;
            } else {
                text.SelectionLength = 0;
                text.SelectionStart = text.TextLength;
            }
        }
        public static void ProcessDelete(this TextBox text) {
            if (text.SelectionLength == 0) text.SelectionLength = 1;
            text.SelectedText = "";
        }
    }
    //your custom DataGridView
    public class CustomDGV : DataGridView { 
        public event EventHandler InnerTextBoxEnterKeyPress;         
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            TextBox childControl = Controls.OfType<TextBox>().FirstOrDefault(c=>c.Focused);
            if (childControl != null) {                
                bool suppress = true;
                switch (keyData) {
                    case Keys.Right:
                        childControl.ProcessRight(false);
                        break;
                    case Keys.Shift | Keys.Right:
                        childControl.ProcessRight(true);
                        break;
                    case Keys.Left:
                        childControl.ProcessLeft(false);
                        break;
                    case Keys.Shift | Keys.Left:
                        childControl.ProcessLeft(true);
                        break;
                    case Keys.End:
                        childControl.ProcessEnd(false);
                        break;
                    case Keys.Home:
                        childControl.ProcessHome(false);
                        break;
                    case Keys.Delete:
                        childControl.ProcessDelete();
                        break;
                    case Keys.Shift | Keys.End:
                        childControl.ProcessEnd(true);
                        break;
                    case Keys.Shift | Keys.Home:
                        childControl.ProcessHome(true);
                        break;
                    case Keys.Control | Keys.C:
                        childControl.Copy();
                        break;
                    case Keys.Control | Keys.X:
                        childControl.Cut();
                        break;
                    case Keys.Control | Keys.V:
                        childControl.Paste();
                        break;
                    case Keys.Enter:
                        EventHandler handler = InnerTextBoxEnterKeyPress;
                        if (handler != null) InnerTextBoxEnterKeyPress(childControl, EventArgs.Empty);
                        Focus();
                        break;
                    default:
                        suppress = false;
                        break;
                }                
                if (suppress) return true;                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }        
    }
