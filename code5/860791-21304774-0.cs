    void MyFormKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                {
                    ButtonOK.PerformClick(); // <- click ButtonOK
                }
        }
