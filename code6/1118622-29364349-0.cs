    var result = from igi in imageGroupImages
                 join i in images on igi.ImageID equals i.ID
                 join ig in imageGroups on igi.ImageGroupID equals ig.ID
                 select new
                 {
                     ImageID = i.ID,
                     ImageUrl = i.Url,
                     GroupID = ig.ID,
                     GroupTitle = ig.Title
                 } into s
                 group s by new { s.GroupID, s.GroupTitle } into gr
                 select new 
                 { 
                     gr.Key.GroupID, 
                     gr.Key.GroupTitle, 
                     Images = gr.Select(c => new 
                                             { 
                                                 c.ImageID, 
                                                 c.ImageUrl 
                                             }) 
                 };
