    // in controller action. I think you might have missed this line 
    ModelState.AddModelError("amount","Amount is invalid!");
    // in view page
    if (HtmlHelper.ValidationMessage("amount") != null && !string.IsNullOrEmpty(HtmlHelper.ValidationMessage("amount").ToHtmlString()))
    {
    //field has error
    }
