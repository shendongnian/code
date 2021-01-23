    // Assuming this is a method in the Space class
    public void Swap(int oldOrder, int newOrder)
    {
        var oldInst = this.Images.FirstOrDefault(si => si.Ordering == oldOrder);
        var newInst = this.Images.FirstOrDefault(si => si.Ordering == newOrder);
        if (oldInst != null && newInst != null)
        {
            oldInst.Ordering = newOrder;
            newInst.Ordering = oldOrder;
        }
        else
        {
            // There weren't matching images - handle that case here
        }
    }
