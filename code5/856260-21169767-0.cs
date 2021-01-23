    var states = Ctx.States.ToList()
                .Select(state => new SelectListItem
                {
                    Text = state.Name,
                    Value = state.Name
                }).OrderBy(x => x.Text).ToList();
