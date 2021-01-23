    var list = db.CCTV_IMAGES.OrderByDescending(u => u.ImageDate);
    return list.Where((d, i) =>
            {
                if (list.ElementAtOrDefault(i + 1) != null)
                {
                    return d.ImageDate.Subtract(list.ElementAtOrDefault(i + 1).ImageDate).TotalMinutes > 30;
                }
                return false;
            }).ToList();
