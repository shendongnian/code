            var posts = new List<Post>();
			posts.Add(new Post { Title = "Foo", Tags = new[] { "Code" } }  );
			posts.Add(new Post { Title = "Foo1", Tags = new[] { "Code", "Productivity" } });
			posts.Add(new Post { Title = "Foo2", Tags = new[] { "Miscellaneous" } });
			var flattendPosts = new List<Post>();
			foreach (var post in posts)
			{
				var tags = post.Tags.Select(tag => tag);				
				for (int i = 0; i < tags.Count(); i++)
				{
					flattendPosts.Add(new Post { Title = post.Title, Tag = post.Tags[i] });
				}				
			}
      
            flattendPosts.GroupBy(post => post.Tags);
