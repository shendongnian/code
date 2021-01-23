     protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
        {
            Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
            e.IsValid = Captcha1.UserValidated;
            if (e.IsValid)
            {
              //do some thing
            }
        }
