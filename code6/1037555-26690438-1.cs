    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace CustomValidatorExample
    {
        public partial class Val : System.Web.UI.Page
        {
            protected void customval_PPSN_ServerValidate(object source, ServerValidateEventArgs args)
            {
                string checkChar = "", formatChar = "", input = tbxPPSN.Text;
                bool newFormat = false;
    
                if (input.Length > 9)
                {
                    args.IsValid = false;
                    return;
                }
    
                if (input.Length == 9)
                {
                    newFormat = true;
                }
    
                char[] PPSArray = input.ToCharArray();
                Array.Reverse(PPSArray);
                checkChar = PPSArray[0].ToString();
    
                if (newFormat)
                {
                    checkChar = PPSArray[1].ToString();
                    formatChar = PPSArray[0].ToString();
                }
    
                checkChar = checkChar.ToLower();
                formatChar = formatChar.ToLower();
    
                int seed = 2, PPSParsed = 0, PPSsum = 0, PPSMod = 0;
    
                foreach (char ppschar in PPSArray)
                {
                    if (int.TryParse(ppschar.ToString(), out PPSParsed))
                    {
                        PPSsum += PPSParsed * seed;
                        seed++;
                    }
                }
    
                if (newFormat)
                {
                    PPSsum += Convert.ToInt32(formatChar.ToCharArray()[0] - 96) * 9;
                }
    
                PPSMod = PPSsum % 23;
    
                if (PPSMod == 0) PPSMod = 23;
    
                if (Convert.ToString((char)(96 + PPSMod)).ToLower() == checkChar)
                {
                    args.IsValid = true;
                    return;
                }
                else
                {
                    args.IsValid = false;
                }
            }
    
            protected void button1_Click(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    Response.Write("Valid");
                }
            }
        }
    }
