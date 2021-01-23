            //
        // POST: /BlogPost/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post, int[] selectedCategories)
        {
           
            if (ModelState.IsValid)
            {
                List<PostMapping> current_list_category = db.PostMappings.Where(p => p.PostID == post.ID).ToList();
            
           
                List<PostMapping> temp = new List<PostMapping>();
                temp.AddRange(current_list_category);
                if (selectedCategories != null)
                {
                    foreach (PostMapping pm in temp)
                    {
                        int categoryId = pm.CategoryID.Value;
                        if (selectedCategories.Contains(categoryId))
                        {
                            selectedCategories = selectedCategories.Where(val => val != categoryId).ToArray();
                        }
                        else
                        {
                            post.PostMappings.Remove(pm);
                            db.Entry(pm).State = EntityState.Deleted;
                        }
                    }
                }
                else
                {
                    foreach (PostMapping pm in temp)
                    {
                        int categoryId = pm.CategoryID.Value;
                        post.PostMappings.Remove(pm);
                        db.Entry(pm).State = EntityState.Deleted;
                    }
                }
    
                if (selectedCategories != null)
                {
                    foreach (var id in selectedCategories)
                    {
                        Category category = db.Categories.Where(c => c.ID == id).SingleOrDefault();
                        PostMapping postMap = new PostMapping();
                        postMap.Category = category;
                        postMap.Post = post;
                        postMap.ID = Guid.NewGuid();
                        post.PostMappings.Add(postMap);
                        category.PostMappings.Add(postMap);
                    }
                }
                
                db.Entry(post).State = EntityState.Modified;
                                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }
