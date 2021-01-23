    var list = db.CCTV_IMAGES.OrderByDescending(u => u.ImageDate);
    return list.Where((d, i) =>
            {
                //Look ahead to compare against the next if it exists.
                if (list.ElementAtOrDefault(i + 1) != null)
                {
                    return d.ImageDate.Subtract(list.ElementAtOrDefault(i + 1).ImageDate).TotalMinutes > 30;
                }
                //Look behind to compare against the previous if this is the last item in the list.
                if (list.ElementAtOrDefault(i - 1) != null)
                {
                    return list.ElementAtOrDefault(i - 1).ImageDate.Subtract(d.ImageDate).TotalMinutes > 30;
                }
                return false;
            }).ToList();
