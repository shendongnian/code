            EWSProxy.FindPeopleType fpType = new EWSProxy.FindPeopleType();
            EWSProxy.IndexedPageViewType indexPageView = new EWSProxy.IndexedPageViewType();
            indexPageView.BasePoint = EWSProxy.IndexBasePointType.Beginning;
            indexPageView.Offset = 0;
            indexPageView.MaxEntriesReturned = 100;
            indexPageView.MaxEntriesReturnedSpecified = true;
            fpType.IndexedPageItemView = indexPageView;
            fpType.ParentFolderId = new EWSProxy.TargetFolderIdType();
            EWSProxy.DistinguishedFolderIdType Gal = new EWSProxy.DistinguishedFolderIdType();
            Gal.Id = EWSProxy.DistinguishedFolderIdNameType.directory;
            fpType.QueryString = "Office";
            fpType.ParentFolderId.Item = Gal;
            EWSProxy.FindPeopleResponseMessageType fpm = null;
            do
            {
                fpm = esb.FindPeople(fpType);
                if (fpm.ResponseClass == EWSProxy.ResponseClassType.Success)
                {
                    foreach (EWSProxy.PersonaType PsCnt in fpm.People)
                    {
                        Console.WriteLine(PsCnt.EmailAddress.EmailAddress);
                    }
                    indexPageView.Offset += fpm.People.Length;
                }
                else
                {
                    throw new Exception("Error");
                }
            } while (fpm.TotalNumberOfPeopleInView > indexPageView.Offset);
