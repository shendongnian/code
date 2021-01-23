           if (query.endDate != null)
            {
                data = data.Where(c => c.UploadDate <= query.endDate).Take(pageSize);
            }
            if (query.startDate != null)
            {
               data = data.Where(c => c.UploadDate >= query.startDate).Take(pageSize);
            }
              
            data = data.OrderByDescending(c => c.UploadDate);
