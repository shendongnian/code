    protected void Button1_Click(object sender, EventArgs e)
        {
            CreateControls();
            if (Button1.Text.Equals("Find"))
            {
    
                for (int i = 0; i < size; i++)
                {
                     TextBox tb = (TextBox)Panel1.FindControl("Number" + i);
                     n[i] = Convert.ToInt32(tb.Text);
                }
               localhost.Search s = new localhost.Search();
               resultLabel = new Label();
               TextBox tb1 = (TextBox)Panel1.FindControl("f1");
               int fNumber = Convert.ToInt32(tb1.Text);            // tb1 is null
             if (s.LinearSearch(n, fNumber))
               resultLabel.Text = "FOUND!";
            else
              resultLabel.Text = "NOT FOUND!";
            form1.Controls.Add(resultLabel);
           }
            else
            {
                Button1.Text = "Find";
            }
    
    
        }
    
        protected void CreateControls()
        {
            var size = Convert.ToInt32(TextBox1.Text);
            var n = new int[size];
                TextBox1.Enabled = false;
                var boxes = new TextBox[size];
                for (int i = 0; i < size; i++)
                {
                    Label l = new Label();
                    l.Text = "Number " + (i + 1) + " : ";
                    boxes[i] = new TextBox();
                    boxes[i].ID = "Number" + i;
                    Panel1.Controls.Add(l);
                    Panel1.Controls.Add(boxes[i]);
                }
                Label l1 = new Label();
                l1.Text = "Find Number : ";
                Panel1.Controls.Add(l1);
                var findBox = new TextBox();
                findBox.ID = "f1";
                Debug.Write("[!D] ID : " + findBox.ID);
                Panel1.Controls.Add(findBox);
               
            }
