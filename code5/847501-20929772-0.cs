    books.Where(b => String.IsNullOrEmpty(b.AuthorCV) || String.IsNullOrEmpty(b.EditorCV)).ToList()
                    .ForEach(b =>
                    {
                        if (String.IsNullOrEmpty(b.AuthorCV))
                        b.AuthorCV = books.FirstOrDefault(x => x.Author == b.Author && !String.IsNullOrEmpty(x.AuthorCV)).AuthorCV;
                        if (String.IsNullOrEmpty(b.EditorCV))
                        b.EditorCV = books.FirstOrDefault(x => x.Editor == b.Editor && !String.IsNullOrEmpty(x.EditorCV)).EditorCV;
                    });
