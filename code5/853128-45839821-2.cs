    private bool isOpen(string name)
            {
                IsOpen = false;
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Text == name)
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    }
                }
    
                if (IsOpen == false)
                {
                    return IsOpen;
                }
                return IsOpen;
            }
