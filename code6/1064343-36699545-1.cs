    public static MvcHtmlString ImageFor<TModel, TProperty, KProperty>(
                this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expressionImageProperty,//this is HttpPostedFile
                Expression<Func<TModel, KProperty>> expressionImageIdProperty,//this property is ID for image that store in database
                object filehtmlAttributes, object imageBoxHtmlAttributes)//html attributes for html controls
            {
                var sb = new StringBuilder();
                var fileattr = new RouteValueDictionary(filehtmlAttributes);
                if (!fileattr.ContainsKey("id"))
                    fileattr.Add("id", string.Format("ImageForFile_{0}", ((MemberExpression)expressionImageProperty.Body).Member.Name));
                fileattr.Add("type", "file");
                if (!fileattr.ContainsKey("class"))
                    fileattr.Add("class", "form-control");
                fileattr.Add("onchange", "readURL(this);");
                sb.Append((string)htmlHelper.TextBoxFor<TModel, TProperty>(expressionImageProperty, fileattr).ToHtmlString());
    
                TagBuilder tagImg = new TagBuilder("img");
                tagImg.Attributes.Add("id", string.Format("ImageForFileViewer_{0}", ((MemberExpression)expressionImageProperty.Body).Member.Name));
    
                if (htmlHelper.ViewData.Model == null)
                    tagImg.Attributes.Add("src",
                        new UrlHelper(HttpContext.Current.Request.RequestContext).Action("GetImage", "ImageManagement",
                            new { imageId = "0" }));
                else
                {
                    var modelImageId = expressionImageIdProperty.Compile()(htmlHelper.ViewData.Model).ToString();
                    if (string.IsNullOrEmpty(modelImageId))
                        modelImageId = "0";
                    tagImg.Attributes.Add("src",
                        new UrlHelper(HttpContext.Current.Request.RequestContext).Action("GetImage", "ImageManagement", //ImageManagementController get FileResult
                            new
                            {
                                imageId = modelImageId,thumb=true,size="small"
                            }));
                }
    
                if (imageBoxHtmlAttributes != null)//
                    tagImg.MergeAttributes(new RouteValueDictionary(imageBoxHtmlAttributes));//
    
                sb.Append(tagImg.ToString(TagRenderMode.Normal));
    
                sb.Append((string)htmlHelper.HiddenFor<TModel, KProperty>(expressionImageIdProperty).ToHtmlString()); //for update
    
                sb.AppendLine(
                   EngineContext.Current.Resolve<IPageScriptManager>()//this is simple mvc script manager resolved from IOC
                                     .ScriptInclude<CommonResourceAccessor>("imageFor" + "_script",
                                                                            "***.WebFramework.Resources.ImageFor.js")//if you have some js file add as resource
                                     .Render().ToString());
                return MvcHtmlString.Create(sb.ToString());
            }
