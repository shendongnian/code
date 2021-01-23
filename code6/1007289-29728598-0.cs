            [Route("{culture}/Produits/{nom_groupe}/{nom}-{id}")]
            [Route("Produits/{nom_groupe}/{nom}-{id}")]
            public ActionResult Detail(string nom_groupe, string nom, string id, string culture = null)
            {
               if(string.IsNullOrWhitespace(culture))    {
                  culture = //Resolve a value for culture here
                }
                // ...   
                return View();
            }
