            if (mHasUpdates) {
                var lHashC = new HashSet<Object>(GroupNames);
                var lHashN = new HashSet<Object>(mGroupList);
                var lAdd = lHashN.Except(lHashC).ToList();
                var lRemove = lHashC.Except(lHashN).ToList();
                if (lAdd.Count > 0 || lRemove.Count > 0) {
                    var lType = GroupNames.GetType();
                    var lProp = lType.GetProperty("Items", lBindingFlags);
                    var lItems = (List<Object>)lProp.GetValue(GroupNames, null);
                    var lMethod = lType.GetMethod("OnCollectionChanged", lBindingFlags, null, new Type[] { typeof(NotifyCollectionChangedEventArgs) }, null);
                    var lArgs = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                    if (lAdd.Count > 0) lItems.AddRange(lAdd);
                    if (lRemove.Count > 0) lItems.RemoveAll(R => lRemove.Contains(R));
                    lMethod.Invoke(GroupNames, new Object[] { lArgs });
                }
            }
