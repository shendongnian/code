    protected void MyButton_Click(object sender, EventArgs e)
        foreach (RepeaterItem repeaterItem in MyRepeater.Items) {
            TextBox myTextBox = (TextBox)repeaterItem.FindControl("MyTextBox");
            var usersData = myTextBox.Text; // Here it is!
        }
    }
