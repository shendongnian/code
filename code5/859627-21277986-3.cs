            var oldObj = _objectiveDetailService.GetObjectiveDetails(id);
            var newObj = objective.ObjectiveDetails.ToList();
            var upd = newObj
                .Where(wb => oldObj
                    .Any(db => (db.ObjectiveDetailId == wb.ObjectiveDetailId) &&
                               (db.Number != wb.Number || !db.Text.Equals(wb.Text))))
                 .ToList();
            newObj.ForEach(wb =>
            {
                var comOld = oldObj.Where(db => wb.ObjectiveDetailId == db.ObjectiveDetailId &&
                               db.Number == wb.Number && db.Text.Equals(wb.Text)).FirstOrDefault();
                if (comOld != null && wb.SubTopics.Any(wb2 => comOld.SubTopics.Where(oldST => wb2.SubTopicId == oldST.SubTopicId).Any(a => !a.Name.Equals(wb2.Name))))
                {
                    upd.Add(wb);
                }
            });
