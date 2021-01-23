                  //Reference for customcontrol class
                   @using WEB_PDD_MVC.CustomHelpers
                   <div>
                    @{
                    List<SelectListItem> fonts = (List<SelectListItem>)ViewBag.vFontlIst;
                    foreach (SelectListItem item in fonts)
                    {
                        if (item.Text == Model.Font)
                        {
                            item.Selected = true;                       
                        }
                        else
                        {
                            item.Selected = false;
                        }
                    }
                                            }
                            @Html.ExtendedDropDownListFor(model => model.Font, fonts,null, new { style = "width: 100px;", id = "ddlFontDropDownList" })
                        </div>
