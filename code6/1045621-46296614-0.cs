    [Route("getProductImage/v1")]
        [HttpGet]
        public async Task<IActionResult> getProductImage(GetProductImageQueryParam parammodel)
        {
            using (HttpClient client = new HttpClient())
            {
                MNimg_URL = MNimg_URL + parammodel.modelname;
                HttpResponseMessage response = await client.GetAsync(MNimg_URL);
                byte[] content = await response.Content.ReadAsByteArrayAsync();
                //return "data:image/png;base64," + Convert.ToBase64String(content);
                return File(content, "image/png", parammodel.modelname);
            }
        }
