    public ActionResult PrepareModifyXInfo(string XNbr_txt)
            {
                // we cannot save anything here to cdll_cdcloanerlist;
                // static variables must be used instead.
    
                /// .... do what you have to do....
              
                return RedirectToAction("ModifyEdit", new { XNbr_txt = XNbr_txt });
            }
