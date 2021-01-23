    Task.Run(
        () =>
            {
                if (MessageBox.Show("Test", "test", MessageBoxButtons.OkCancel) == DialogResult.OK)
                {
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("Cancel");
                }
            }
        );
