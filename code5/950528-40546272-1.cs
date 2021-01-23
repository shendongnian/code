    using System;  
    using System.Diagnostics;  
    using System.IO;  
    using System.Runtime.InteropServices;  
    using System.Threading;  
    using System.Windows.Forms;  
      
    namespace DayView  
    {  
        public class StickyNote  
        {  
            private const string m_ProcessName = "StikyNot";  
            private readonly string m_ProcessFileName = Path.Combine(Environment.SystemDirectory, "StikyNot.exe");  
            private event EventHandler m_Activated = delegate { };  
            [DllImport("user32.dll")]  
            [return: MarshalAs(UnmanagedType.Bool)]  
            static extern bool SetForegroundWindow(IntPtr hWnd);  
      
            public void Activate()  
            {  
                bool makeNewNote = true;  
                Process p = FindProcess();  
                if (p == null)  
                {  
                    p = StartProcess();  
                    if (!NoteContainsText(p.MainWindowHandle))  
                    {  
                        makeNewNote = false;  
                    }  
                }  
                var state = new StickyNoteState();  
                state.MakeNewNote = makeNewNote;  
                state.StickyNoteProcess = p;  
                ThreadPool.QueueUserWorkItem(Activate, state);  
            }  
      
            private void Activate(object state)  
            {  
                var stickyNoteState = state as StickyNoteState;  
                if (stickyNoteState.MakeNewNote)  
                {  
                    NewNote(stickyNoteState.StickyNoteProcess);  
                }  
                OnActivated();  
            }  
      
            private Process StartProcess()  
            {  
                var startInfo = new ProcessStartInfo(m_ProcessFileName);  
                Process p = Process.Start(startInfo);  
                Thread.Sleep(200); //This is an annoying hack. I haven't been able to find another way to be sure the process is started.  
                return p;  
            }  
      
            private void NewNote(Process p)  
            {  
                SetForegroundWindow(p.MainWindowHandle);  
                Signal("^n");              
            }  
      
            /// <summary>  
            /// Weird hack to find out if note contains text.  
            /// </summary>  
            /// <returns></returns>  
            private bool NoteContainsText(IntPtr handle)  
            {  
                string textOfClipboard = Clipboard.GetText();  
                Signal("^a");  
                Signal("^c");  
                Signal("{RIGHT}");  
                string noteText = Clipboard.GetText().Trim();  
                if (textOfClipboard == null)  
                {  
                    Clipboard.SetText(textOfClipboard);  
                }  
                return !string.IsNullOrEmpty(noteText);  
            }  
      
            private Process FindProcess()  
            {  
                    Process[] processes = Process.GetProcessesByName(m_ProcessName);  
                    if(processes != null && processes.Length > 0)  
                    {  
                        return processes[0];  
                    }  
                return null;  
            }  
      
            internal void OnActivated()  
            {  
                m_Activated(this, new EventArgs());  
            }  
      
            public event EventHandler Activated  
            {  
                add { m_Activated += value; }  
                remove { m_Activated -= value; }  
            }  
      
            public void Signal(string message)  
            {  
                SendKeys.SendWait(message);  
                SendKeys.Flush();  
            }  
        }  
      
        public class StickyNoteState  
        {  
            public bool MakeNewNote { get; set; }  
            public Process StickyNoteProcess { get; set; }  
      
        }  
    }  
