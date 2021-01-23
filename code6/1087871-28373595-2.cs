        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var calendarEvent = await calendarService.FindByIdAsync(id);
            if (calendarEvent == null) return this.RedirectToAction<CalendarController>(c => c.Index());
            var model = new CalendarEditViewModel(calendarEvent);
            ViewData.Model = model;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, CalendarEventBindingModel binding)
        {
            if (!ModelState.IsValid) return await Edit(id);
            
            var calendarEvent = await calendarService.FindByIdAsync(id);
            if (calendarEvent != null)
            {
                CalendarEvent model = calendarService.Update(calendarEvent, binding);
                await context.SaveChangesAsync();
            }
            return this.RedirectToAction<CalendarController>(c => c.Index());
        }
