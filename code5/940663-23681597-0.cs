     protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
            {
                try
                {
                    return !virtualPath.EndsWith("cshtml") &&
                        File.Exists(controllerContext.HttpContext.Server.MapPath(virtualPath));
                }
                catch (HttpException exception)
                {
                    if (exception.GetHttpCode() != 0x194)
                    {
                        throw;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
