    ResponseFilters.Add((req, res, dto) =>
            {
                if (req.ResponseContentType == "text/x-tapas")
                {
                    res.AddHeader(HttpHeaders.ContentDisposition,
                        string.Format("attachment;filename={0}.csv", req.OperationName));
                }
            });
