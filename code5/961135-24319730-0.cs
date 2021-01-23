    PagePublishVM.galleryFileVMs = (
                from tn in db.Media
                where tn.GalleryId == galleryId
                orderby tn.SortOrder
                select new galleryFileVM
                {
                    MediaId = tn.MediaId,
                    FileTypeId = (int)tn.File.FileTypeId,
                    FileName = tn.File.FileName,
                    FileNameSlug = tn.File.FileNameSlug,
                    SortOrder = tn.SortOrder,
                    OrigH = tn.OrigHeight,
                    OrigW = tn.OrigWidth,
                    galleryFileDescVMs = (from fd in db.FileDescendants
											where fd.FileId == tn.FileId
											select new galleryFileDescVM
											{
												// Guessing here because I don't have the schema
												Drive = fd.Drive,
												Prefix = fd.Prefix,
												// etc.
											}).ToList()
                })
                .ToList();
