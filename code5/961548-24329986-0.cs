        public ActionResult Testing()
        {
            var data = new Dictionary<dynamic, Tuple<dynamic, dynamic>>
            {
                {1, new Tuple<dynamic, dynamic>(new Project{Name = "P1"}, new Segment{Id = "S1"})},
            };
            return View(data);
        }
        @foreach (var d in @Model)
              {
                      var item1 = @d.Value.Item1 as Project;
                      var item2 = @d.Value.Item2 as Segment;
                      <p> @d.Key + ": "  + @item1.Name + " - " + @item2.Id</p>
              }
