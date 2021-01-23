    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    namespace test
    {
        public partial class Form1 : Form
        {
            
            [DllImport("user32.dll")]
            static extern int GetForegroundWindow();
            [DllImport("user32.dll")]
            static extern short GetKeyState(VirtualKeyStates nVirtKey);
            enum VirtualKeyStates : int
            {
                VK_LBUTTON = 0x01,
                VK_RBUTTON = 0x02,
            }
            
            bool IsKeyPressed(VirtualKeyStates testKey)
            {
                bool keyPressed = false;
                short result = GetKeyState(testKey);
                switch (result)
                {
                    case 0:
                        keyPressed = false;
                        break;
                    case 1:
                        keyPressed = false;
                        break;
                    default:
                        keyPressed = true;
                        break;
                }
                return keyPressed;
            }
            int GetActiveWindowHandle()
            {
                const int nChars = 256;
                int handle = 0;
                StringBuilder Buff = new StringBuilder(nChars);
                handle = GetForegroundWindow();
                if (GetWindowText(handle, Buff, nChars) > 0)
                    return handle;
                else
                    return 0;
            }
            private string GetWindowsExplorerPathFromWindowHandle(int handle)
            {
                // Add a project COM reference to Microsoft Internet Controls 1.1
                SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindowsClass(); 
                string fileName;
                string path = "";
                foreach ( SHDocVw.InternetExplorer ie in shellWindows )
                {    
                    fileName = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                    if (fileName.Equals("explorer") && ie.HWND == handle)
                    {
                        path = ie.LocationURL;
                        path = path.ToLower();
                        path = path.Replace("file://", "");
                        if (path.StartsWith("/"))
                            path = path.Substring(1);
                        path = path.Replace("/", "\\");
                        if (!path.Contains(":")) // unc paths
                            path = "\\\\" + path;
                        break;
                    }
                }
                return path; 
            }
            // Replace the created event from the designer with this event:
            //
            private void lvFiles_ItemDrag(object sender, ItemDragEventArgs e)
            {
                // fake drag and drop effect (start)
                string dataFormat = DataFormats.FileDrop;
                string[] data = new string[1];
                data[0] = "";
                DataObject dataObject = new DataObject(dataFormat, data);
                // catch mouse events
                if (IsKeyPressed(VirtualKeyStates.VK_LBUTTON))
                    MouseButtonPressed = MouseButtons.Left;
                else if (IsKeyPressed(VirtualKeyStates.VK_RBUTTON))
                    MouseButtonPressed = MouseButtons.Right;
                else
                    MouseButtonPressed = MouseButtons.None;
                if (MouseButtonPressed == MouseButtons.Left || MouseButtonPressed == MouseButtons.Right) 
                    this.dropTimer.Enabled = true;
                // fake drag and drop effect (launch)
                DoDragDrop(dataObject, DragDropEffects.Copy);
            }
            
            
            private void dropTimer_Tick(object sender, EventArgs e)
            {
                bool mouseButtonsReleased = false;
                if (MouseButtonPressed == MouseButtons.Left && !IsKeyPressed(VirtualKeyStates.VK_LBUTTON))
                    mouseButtonsReleased = true;
                else if (MouseButtonPressed == MouseButtons.Right && !IsKeyPressed(VirtualKeyStates.VK_RBUTTON))
                    mouseButtonsReleased = true;
                if (mouseButtonsReleased)
                {
                    dropTimer.Enabled = false;
                    int handle = GetActiveWindowHandle();
                    string dropPath = GetWindowsExplorerPathFromWindowHandle(handle);
                    MessageBox.Show(dropPath); // Here is where the Windows Explorer path is shown
                }
            }
            
        }
    }
