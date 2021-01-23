    using (var file = new System.IO.FileStream(@"sample.log", System.IO.FileMode.Open))
            {
                var fileInfo = new FILE_BASIC_INFO();
                GetFileInformationByHandleEx(
                    file.Handle,
                    FILE_INFO_BY_HANDLE_CLASS.FileBasicInfo,
                    out fileInfo,
                    (uint)System.Runtime.InteropServices.Marshal.SizeOf(fileInfo));
                var changeTime = DateTime.FromFileTime(fileInfo.ChangeTime.QuadPart);
                Console.WriteLine(changeTime);
                System.TimeSpan changedForHowLong = DateTime.Now.Subtract(changeTime);
                Console.WriteLine(changedForHowLong.Days);
            }
