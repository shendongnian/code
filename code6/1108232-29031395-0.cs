        public void Notepad() {
            Application app = Application.Launch("notepad.exe");
            Window window = app.GetWindow("Untitled - Notepad");
            // Change text
            var box = window.Get(SearchCriteria.ByClassName("Edit"));
            Keyboard.Instance.Send("test", box);
            // Save
            window.MenuBar.MenuItem("File", "Save As...").Click();
            var filename = window.Get(SearchCriteria.ByClassName("Edit"));
            Keyboard.Instance.Send(DateTime.Now.ToString("yyyyMMddHHmmssffff") + "test.txt", filename);
            window.Get(SearchCriteria.ByText("Save")).Click();
            app.Kill();
        }
