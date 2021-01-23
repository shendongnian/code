     if (ViewState["hasvalue"].ToString() == "Clicked")
                {
                HtmlPage.Window.Navigate(new Uri("form2.aspx"), "_self");
                }
                else // First Time it will be opened in New TAB
                {
                   
          Hyperlink1.target="_blank";
        Hyperlink1.NavigateUrl="form2.aspx";
        
                
        }
        
          // Assign this value to session
        ViewState["hasvalue"] = "Clicked";
        }
