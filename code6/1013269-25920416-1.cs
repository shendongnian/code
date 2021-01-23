        static IEnumerable<Image> GetThumbnails(Stream stream)
        {
            byte[] allImages;
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                allImages = ms.ToArray();
            }
            var bof = allImages.Take(8).ToArray(); //??
            var prevOffset = -1;
            foreach (var offset in GetBytePatternPositions(allImages, bof))
            {
                if (prevOffset > -1)
                    yield return GetImageAt(allImages, prevOffset, offset);
                prevOffset = offset;
            }
            if (prevOffset > -1)
                yield return GetImageAt(allImages, prevOffset, allImages.Length);
        }
        static Image GetImageAt(byte[] data, int start, int end)
        {
            using (var ms = new MemoryStream(end - start))
            {
                ms.Write(data, start, end - start);
                return Image.FromStream(ms);
            }
        }
        static IEnumerable<int> GetBytePatternPositions(byte[] data, byte[] pattern)
        {
            var dataLen = data.Length;
            var patternLen = pattern.Length - 1;
            int scanData = 0;
            int scanPattern = 0;
            while (scanData < dataLen)
            {
                if (pattern[0] == data[scanData])
                {
                    scanPattern = 1;
                    scanData++;
                    while (pattern[scanPattern] == data[scanData])
                    {
                        if (scanPattern == patternLen)
                        {
                            yield return scanData - patternLen;
                            break;
                        }
                        scanPattern++;
                        scanData++;
                    }
                }
                scanData++;
            }
        }
