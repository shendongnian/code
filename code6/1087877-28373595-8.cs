        [HttpGet, ImportModelStateFromTempData]
        public async Task<ActionResult> Edit(Guid id)
        {
            var calendarEvent = await calendarService.FindByIdAsync(id);
            if (calendarEvent == null) return this.RedirectToAction<CalendarController>(c => c.Index());
            var model = new CalendarEditViewModel(calendarEvent);
            ViewData.Model = model;
            return View();
        }
        // ActionResult changed to RedirectToRouteResult
        [HttpPost, ValidateModelState]
        public async Task<RedirectToRouteResult> Edit(Guid id, CalendarEventBindingModel binding)
        {
            // removed ModelState.IsValid check
            var calendarEvent = await calendarService.FindByIdAsync(id);
            if (calendarEvent != null)
            {
                CalendarEvent model = calendarService.Update(calendarEvent, binding);
                await context.SaveChangesAsync();
            }
            return this.RedirectToAction<CalendarController>(c => c.Index());
        }
