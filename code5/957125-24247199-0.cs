     List<Control> controls = new List<Control>();
            //Add controls
            foreach (Control item in controls)
            {
                item.Visible = true;
                if (item is MyCustomButton)
                {
                    ((MyCustomButton)item).CustomProperty = "123";
                }
            }
