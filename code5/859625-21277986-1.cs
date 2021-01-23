            var oldObj = _objectiveDetailService.GetObjectiveDetails(id);
            var newObj = objective.ObjectiveDetails.ToList();
            var updSubTopic = new List<ObjectiveDetail>();
            newObj
                .Where(wb => oldObj
                    .Any(db => (db.ObjectiveDetailId == wb.ObjectiveDetailId) &&
                               (db.Number != wb.Number || !db.Text.Equals(wb.Text))))
                 .ToList().ForEach(wb2 =>
                 {
                     var comOld = oldObj.Where(db2 => wb2.ObjectiveDetailId == db2.ObjectiveDetailId).FirstOrDefault();//You might want to tweek this
                     if (comOld != null && wb2.SubTopics.Any(stnew => comOld.SubTopics.Where(stold => stnew.SubTopicId == stold.SubTopicId).Any(a => !a.Name.Equals(stnew.Name))))
                     {
                         updSubTopic.Add(wb2);
                     }
                 });
