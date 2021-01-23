    foreach(GroupBox gb in this.Controls.OfType<GroupBox>())
    }
        foreach(RadioButton rb in gb.Controls.OfType<RadioButton>())
        {
            rb.CheckedChanged += new System.EventHandler(radioButton_CheckedChanged);
        }
    }
