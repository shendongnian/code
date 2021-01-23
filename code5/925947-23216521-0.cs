    tbRole.MouseLeave += (senderL, eL) =>
         {
            boolText == false;
            
            if(boolText == false && boolPic == false) {
                pnRole.BackColor = Color.Bisque;
                tbRole.BackColor = Color.Bisque;
                pbDeleteX.Visible = false;
            }
         };
