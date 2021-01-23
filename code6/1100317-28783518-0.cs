    [Test]
    public void SanityCheck()
    {
        var rawOptions = new[] { (int?)null, 0, 1 };
        var selectList = new SelectList(rawOptions.Select(a => new SelectListItem { Value = a.ToString(), Text = a.ToString() }));
        Assert.That(selectList.Items.Cast<SelectListItem>.Count(item => String.IsNullOrEmpty(item.Value)), Is.EqualTo(1));
    }
