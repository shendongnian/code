                var js = new JavaScriptSerializer();
                js.RegisterConverters(new JavaScriptConverter[] { new JavaScriptImageConverter() });
                js.MaxJsonLength = int.MaxValue / 8; // Because my test string turned out to be VERY LONG.
                var imageJson = js.Serialize(item);
                using (var itemBack = js.Deserialize<Item>(imageJson))
                {
                    var ok1 = itemBack.Images.SelectMany(p => p.Value).Select(i => i.Width).SequenceEqual(item.Images.SelectMany(p => p.Value).Select(i => i.Width));
                    Debug.Assert(ok1); // No assert.
                    var ok2 = itemBack.Images.SelectMany(p => p.Value).Select(i => i.Height).SequenceEqual(item.Images.SelectMany(p => p.Value).Select(i => i.Height));
                    Debug.Assert(ok2); // No assert.
                }
