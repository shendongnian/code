        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            dynamic model = null;
            string request = string.Empty;
            
            try
            {
                request = await Request.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<ExpandoObject>(request);
                model.Template = RequestHelper.FromBase64(model.TemplateEncoded);
				
				// here you could do some validation, if required.
				
                var razorResult = Razor.Parse(model.Template, model);
                var result = HttpUtility.HtmlDecode(razorResult);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(request, model == null ? "ERROR: template was not converted from base64 encoded string." : model.Template, ex);
                return InternalServerError(ex);
            }
        } 
