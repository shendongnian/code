    [HttpPost]
            public async Task<ActionResult> Create(RegisterViewModel userViewModel, params string[] selectedRoles)
            {
                if (ModelState.IsValid)
                {...}
            }
