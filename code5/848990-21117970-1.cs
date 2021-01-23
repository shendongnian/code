    //Extension method.
    public static void TransformRedirect(this HttpResponse response, 
                                         string redirectUrl)
    {
        //Transform url here.
        response.Redirect(redirectUrl);
    }
    //And when redirecting.
    Response.TransformRedirect("RedirectTarget.aspx");
