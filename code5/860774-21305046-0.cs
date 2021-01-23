    Button btn = new Button();
    btn.Location = new Point(yourX, yourY);
    btn.Font = new Font(btn.Font.Name, 10);
    btn.Text = "Text from your txt file here";
    btn.ForeColor = Color.SeaShell; // choose color
    btn.AutoSize = true;
    btn.Click += (sender, eventArgs) =>
    				{
    				    string text = btn.Text.Replace("System.Windows.Controls.Button: ", "");  
                        WebBrowser1.Navigate(text);
    				};
