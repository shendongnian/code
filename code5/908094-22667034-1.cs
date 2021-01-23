    // line 483, HtmlTextController.cs, DNN code included for positioning
    while (P != -1)
        {
            sbBuff.Append(strHTML.Substring(S, P - S + tLen));
            
            // added code
            bool skipThisToken = false;
            if (strHTML.Substring(P + tLen, 10) == "data:image")  // check for base64 image
                skipThisToken = true;
            // end added code - back to standard DNN
            //keep characters left of URL
            S = P + tLen;
            //save startpos of URL
            R = strHTML.IndexOf("\"", S);
            //end of URL
            if (R >= 0)
            {
                strURL = strHTML.Substring(S, R - S).ToLower();
            }
            else
            {
                strURL = strHTML.Substring(S).ToLower();
            }
            // added code to continue while loop after the integers were updated
            if (skipThisToken)
            {
                 P = strHTML.IndexOf(strToken + "=\"", S + strURL.Length + 2, StringComparison.InvariantCultureIgnoreCase);
                 continue;
            }
            // end added code -- the method continues from here (not reproduced)
