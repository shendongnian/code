    switch (id)
        {
            case 1:
                await Task.Delay(2000);
                this.BackColor = System.Drawing.Color.Red;
                break;
            case 2:
                await Task.Delay(2000);
                this.BackColor = System.Drawing.Color.White;
                break;
        }
