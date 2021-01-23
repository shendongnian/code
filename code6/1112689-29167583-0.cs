            Random rnd = new Random();
            int colorNum = rnd.Next(1, 4);
            switch (colorNum)
            {
                case 1:
                    btnRed.BackColor = Color.Red;
                    btnBlue.BackColor = Color.LightGray;
                    btnYellow.BackColor = Color.LightGray;
                    break;
                case 2:
                    btnBlue.BackColor = Color.Blue;
                    btnRed.BackColor = Color.LightGray;
                    btnYellow.BackColor = Color.LightGray;
                    break;
                case 3:
                    btnYellow.BackColor = Color.Yellow;
                    btnRed.BackColor = Color.LightGray;
                    btnBlue.BackColor = Color.LightGray;
                    break;
            }
        }
