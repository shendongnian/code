        [HttpPost, ValidateModelState, ExportModelStateToTempData]
        public async Task<RedirectToRouteResult> Edit(Guid id, CalendarEventBindingModel binding)
        {
            
            var calendarEvent = await calendarService.FindByIdAsync(id);
            if (!(calendarEvent.DateStart > DateTime.UtcNow.AddDays(7))
                && binding.DateStart != calendarEvent.DateStart)
            {
                ModelState.AddModelError("id", "Sorry, Date start cannot be updated with less than 7 days of event.");
                return RedirectToAction("Edit", new { id });
            }
            if (calendarEvent != null)
            {
                CalendarEvent model = calendarService.Update(calendarEvent, binding);
                await context.SaveChangesAsync();
            }
            return this.RedirectToAction<CalendarController>(c => c.Index());
        }
