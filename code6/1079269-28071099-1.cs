    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Deactivate(Staff staff)
    {
      try
      {
        ...
        staffRepository.DeactivateStaff(staff);
        await staffRepository.SaveAsync();
        return RedirectToAction("Index");
      }
      ...
    }
