    @using (Html.BeginForm("userResults", "User", new AjaxOptions()
                        {
                            HttpMethod = "GET",
                            UpdateTargetId = "results",
                            InsertionMode = InsertionMode.Replace
                        }))
