    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    using System.Runtime.InteropServices;
    
    namespace ProgramIO.Control
    {
        public delegate void WriteDelegate(string value, int x, int y);
        public delegate void ReadDelegate(out string value, bool readLine);
        public delegate void EnableInputDelegate(bool enable);
    
        public partial class InteractiveForm : Form
        {
            private delegate void ClearInputBufferDelegate();
    
            public enum EIOOperation { None = 0, Write, Read }
    
            private EventWaitHandle eventInvoke =
                new EventWaitHandle(false, EventResetMode.AutoReset);
            private EventWaitHandle eventInput =
                new EventWaitHandle(false, EventResetMode.AutoReset);
            private bool readLine = false;
            private string inputBuffer = "";
            private int inputPosition = 0;
            private int inputBufferPosition = 0;
            private EIOOperation IOOperation;
            private int bufferSize = 0x10000;
            private bool CaretShown = false;
    
            private delegate object DoInvokeDelegate(Delegate method, params object[] args);
            private delegate void SetTitleDelegate(string value);
            private delegate void SetForegroundcolorDelegate(Color value);
    
            public string Title {
                get { return Text; }
                set {
                    if (InvokeRequired) InvokeEx(
                        (SetTitleDelegate)delegate(string title) { Text = title; },
                        1000, new object[] { value });
                    else Text = value; }}
            public Color ForegroundColor {
                get { return ForeColor; }
                set {
                    if (InvokeRequired) InvokeEx(
                        (SetForegroundcolorDelegate)delegate(Color color) { ForeColor = color; },
                        1000, new object[] { value });
                    else ForeColor = value; }}
    
            public InteractiveForm()
            {
                InitializeComponent();
                DoubleBuffered = true;
            }
    
            #region Asynchronous Methods
            private bool InvokeEx(Delegate method, int timeout, params object[] args)
            {
                BeginInvoke((DoInvokeDelegate)DoInvoke, new object[] { method, args });
                if (eventInvoke.WaitOne(timeout)) return true;
                else return false;
            }
            private void EnableInput(bool enable)
            {
                if (InvokeRequired)
                    InvokeEx((EnableInputDelegate)DoEnableInput, 1000, new object[] { enable });
                else DoEnableInput(enable);
            }
            private void ClearInputBuffer()
            {
                if (InvokeRequired)
                    InvokeEx((ClearInputBufferDelegate)DoClearInputBuffer, 1000, new object[0]);
                else DoClearInputBuffer();
            }
            public void Write(string value, int x = -1, int y = -1)
            {
                lock (this) {
                    IOOperation = EIOOperation.Write;
                    if (InvokeRequired)
                        InvokeEx((WriteDelegate)DoWrite, 1000, new object[] { value, x, y });
                    else DoWrite(value, x, y);
                    IOOperation = EIOOperation.None; }
            }
            public string Read(bool readLine)
            {
                lock (this) {
                    EnableInput(true);
                    IOOperation = EIOOperation.Read; this.readLine = readLine; string value = "";
                    ClearInputBuffer(); eventInput.WaitOne();
                    object[] args = new object[] { value, readLine };
                    if (InvokeRequired) {
                        InvokeEx((ReadDelegate)DoRead, 1000, args); value = (string) args[0]; }
                    else DoRead(out value, readLine);
                    //inputPosition = textBox.Text.Length; inputBuffer = "";
                    ClearInputBuffer();
                    IOOperation = EIOOperation.None;
                    EnableInput(false);
                    return value;
                }
            }
            #endregion //Asynchronous Methods
    
            #region Synchronous Methods
            protected override void OnShown(EventArgs e) { base.OnShown(e); textBox.Focus(); }
            public object DoInvoke(Delegate method, params object[] args)
            {
                object obj = method.DynamicInvoke(args);
                eventInvoke.Set();
                return obj;
            }
            private void CorrectSelection()
            {
                if (textBox.SelectionStart < inputPosition) {
                    if (textBox.SelectionLength > (inputPosition - textBox.SelectionStart))
                        textBox.SelectionLength -= inputPosition - textBox.SelectionStart;
                    else textBox.SelectionLength = 0;
                    textBox.SelectionStart = inputPosition; }
            }
            protected void DoClearInputBuffer()
            {
                inputPosition = textBox.Text.Length; inputBuffer = "";
            }
            protected void DoEnableInput(bool enable)
            {
                if (enable) { textBox.ReadOnly = false; textBox.SetCaret(true); }
                else { textBox.ReadOnly = true; textBox.SetCaret(false); }
            }
            protected void DoWrite(string value, int x, int y)
            {
                string[] lines = textBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                string[] addLines = new string[0];
    
                if (y == -1) y = lines.Length - 1;
                if (lines.Length - 1 < y) addLines = new string[y - lines.Length - 1];
                
                if (y < lines.Length) {
                    if (x == -1) x = lines[y].Length;
                    if (lines[y].Length < x)
                        lines[y] += new String(' ', x - lines[y].Length) + value;
                    else
                        lines[y] = lines[y].Substring(0, x) + value +
                            ((x + value.Length) < lines[y].Length ?
                                lines[y].Substring(x + value.Length) : ""); }
                else {
                    y -= lines.Length;
                    if (x == -1) x = addLines[y].Length;
                    addLines[y] += new String(' ', x - addLines[y].Length) + value; }
    
                textBox.Text = (string.Join("\r\n", lines) +
                    (addLines.Length > 0 ? "\r\n" : "") + string.Join("\r\n", addLines));
                textBox.Select(textBox.Text.Length, 0); textBox.ScrollToCaret();
                inputBuffer = "";
            }
            protected void DoRead(out string value, bool readLine)
            {
                value = "";
                if (readLine) {
                    int count = inputBuffer.IndexOf("\r\n");
                    if (count > 0) { value = inputBuffer.Substring(0, count); }}
                else if (inputBuffer.Length > 0) {
                    value = inputBuffer.Substring(0, 1); }
                inputBuffer = "";
            }
            private void textBox_TextChanged(object sender, EventArgs e)
            {
                if (IOOperation == EIOOperation.Read) {
                    inputBuffer = textBox.Text.Substring(inputPosition);
                    if (!readLine || inputBuffer.Contains("\r\n")) eventInput.Set(); }
    
                if (textBox.Text.Length > bufferSize) { textBox.Text =
                    textBox.Text.Substring(textBox.Text.Length - bufferSize, bufferSize);
                    textBox.Select(textBox.Text.Length, 0); textBox.ScrollToCaret(); }
            }
            private void textBox_KeyDown(object sender, KeyEventArgs e)
            {
                if (IOOperation != EIOOperation.Read || 
                    (e.KeyCode == Keys.Back && inputBuffer.Length == 0))
                    e.SuppressKeyPress = true;
            }
            private void textBox_MouseUp(object sender, MouseEventArgs e)
            {
                CorrectSelection();
            }
            private void textBox_KeyUp(object sender, KeyEventArgs e)
            {
                if (!(IOOperation == EIOOperation.Read) ||
                    ((e.KeyCode == Keys.Left || e.KeyCode == Keys.Up) &&
                    textBox.SelectionStart < inputPosition))
                    CorrectSelection();
            }
            private void InteractiveForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                eventInput.Set();
                lock (this) { }
            }
            #endregion //Synchronous Methods
        }
    
        public class InteractiveWindow : TextBox
        {
            [DllImport("user32.dll")]
            static extern bool HideCaret(IntPtr hWnd);
            [DllImport("user32.dll")]
            static extern bool ShowCaret(IntPtr hWnd);
    
            private delegate void SetCaretDelegate(bool visible);
    
            private const int WM_SETFOCUS = 0x0007;
            private bool CaretVisible = true;
    
            public void SetCaret(bool visible)
            {
                if (InvokeRequired) Invoke((SetCaretDelegate)DoSetCaret, new object[] { visible });
                else DoSetCaret(visible);
            }
            private void DoSetCaret(bool visible)
            {
                if (CaretVisible != visible)
                {
                    CaretVisible = visible;
                    if (CaretVisible) ShowCaret(Handle);
                    else HideCaret(Handle);
                }
            }
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_SETFOCUS)
                {
                    if (CaretVisible) { ShowCaret(Handle); }
                    else HideCaret(Handle);
                }
            }
        }
    }
    
    namespace ProgramIO
    {
        using ProgramIO.Control;
        public static class Interactive
        {
            public delegate void StopedDelegate();
            public delegate void RunDelegate();
    
            public static bool Initialized = false;
            private static InteractiveForm frmIO = null;
            private static Thread IOThread = null;
            private static EventWaitHandle EventStarted =
                new EventWaitHandle(false, EventResetMode.AutoReset);
    
            public static string Title {
                get { return frmIO.Title; }
                set { frmIO.Title = value; } }
            public static Color ForegroundColor {
                get {return frmIO.ForeColor; }
                set { frmIO.ForeColor = value; } }
            public static event StopedDelegate OnStopped = null;
    
            private static void form_Show(object sender, EventArgs e)
            {
                frmIO = sender as InteractiveForm;
                EventStarted.Set();
            }
            private static void form_FormClosed(object sender, FormClosedEventArgs e)
            {
                lock (frmIO) {
                    frmIO = null;
                    Application.Exit(); }
            }
            public static void Initialize()
            {
                IOThread = new Thread(IOThreadProc);
                IOThread.Name = "Interactive Thread"; IOThread.Start();
                EventStarted.WaitOne();
                Initialized = true;
            }
            public static void Run(RunDelegate runProc = null)
            {
                if (!Initialized) Initialize();
                if (runProc != null) runProc();
                Application.Run();
                if (OnStopped != null) OnStopped();
            }
            public static void IOThreadProc()
            {
                InteractiveForm form = new InteractiveForm();
                form.Shown += new EventHandler(form_Show);
                form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                Application.Run(form);
            }
            public static void Write(string value, int x = -1, int y = -1)
            {
                if (frmIO != null) lock (frmIO) { frmIO.Write(value, x, y); }
            }
            public static void WriteLine(string value)
            {
                if (frmIO != null) lock (frmIO) {
                    Interactive.Write(value); Interactive.Write("\r\n"); }
            }
            public static int Read()
            {
                if (frmIO != null) lock (frmIO) {
                    string input = frmIO.Read(false);
                    if (input.Length > 0) return input[0]; }
                return 0;
            }
            public static string ReadLine()
            {
                if (frmIO != null) lock (frmIO) { return frmIO.Read(true); }
                else return "";
            }
        }
    }
