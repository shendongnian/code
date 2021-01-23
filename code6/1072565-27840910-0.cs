    string textToPrint = string.empty;
    foreach (GridViewRow row in grdProducts.Rows)
        {
            textToPrint += "A<br />";
        }
    
    Response.Write(textToPrint);
