    @{
                            
        var ImageFile = System.Web.HttpContext.Current.Server.MapPath("~/Document/Picture/" + @Request.Cookies["sTimeStamp"].Value + ".jpg");
        var PanFile = System.Web.HttpContext.Current.Server.MapPath("~/Document/PAN/" + @Request.Cookies["sTimeStamp"].Value + ".jpg");
        var AdhaarFile = System.Web.HttpContext.Current.Server.MapPath("~/Document/Adhaar/" + @Request.Cookies["sTimeStamp"].Value + ".jpg");
    }
    @if (System.IO.File.Exists(ImageFile) == false || System.IO.File.Exists(PanFile) == false || System.IO.File.Exists(AdhaarFile) == false)
    {
        ViewBag.KycMessage = "Your KYC has not completed yet. KYC is mandatory to get payment you earned. Following is list of document which is not uploaded.";
    }
    else
    {
        ViewBag.KycMessage = "<span style=\"color:green\">KYC Comlete</span>";
    }
                        
    <span>@ViewBag.KycMessage</span>
