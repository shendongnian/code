        int num;
        if (this.Tree.GetType() == Main.TestInt.GetType())
        {
            if (int.TryParse(this.TextBox.Text,out num)) //1,  you were parsing label.Text
            {
                this.Tree.SetInfo(num); //2, don't bother parsing it twice!
                base.label.Text = base.TextBox.Text;
            }
            else
            {
                base.TextBox.Text = "";
                MessageBox.Show("Only Numbers Allowed", "Error");
            }
        }
