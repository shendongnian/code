            double eng, urdu, math, cs, tot, per;
            eng = Convert.ToDouble(txtenglish.Text);
            urdu = Convert.ToDouble(txturdu.Text);
            math = Convert.ToDouble(txtmath.Text);
            cs = Convert.ToDouble(txtcs.Text);
            tot = eng + urdu + math + cs;
            lbltotal.Text = Convert.ToString(tot);
            
            per = (tot / 400) * 100;
            lblpercent.Text = Convert.ToString(per);
        }
