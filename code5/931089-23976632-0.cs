        private void DrawPerformanceMetricsFlatList()
        {
            foreach (var type in PerformanceTestingTypes.GetTypes())
            {
                var performanceTestingType = typeof(PerformanceTesting<>);
                Type[] typeArgs = { type };
                var genericType = performanceTestingType.MakeGenericType(typeArgs);
                var data = genericType.GetProperty("Instance", BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.Public).GetGetMethod().Invoke(null, null);
                var totalMilli = data.GetType().GetMethod("TotalMilliseconds", new[] { type });
                var avgMilli = data.GetType().GetMethod("AverageMilliseconds", new[] { type });
                var totalTicks = data.GetType().GetMethod("TotalTicks", new[] { type });
                var avgTicks = data.GetType().GetMethod("AverageTicks", new[] { type });
                var startCount = data.GetType().GetMethod("GetStartCount", new[] { type });
                var fromConverter = data.GetType().GetProperty("ConvertFromStringCallback");
                // var toConverter = data.GetType().GetProperty("ConvertToStringCallback", new[] { type });
                var func = fromConverter.GetGetMethod().Invoke(data, null);
                var invoker = func.GetType().GetMethod("Invoke");
                var keyNames = PerformanceTestingTypes.GetKeyNames(type);
                switch (this.sortIndex)
                {
                    case 1:
                        keyNames = keyNames.OrderBy(x => x).ToArray();
                        break;
                    case 2:
                           keyNames = keyNames.OrderByDescending(x => totalTicks.Invoke(data, new[] { invoker.Invoke(func, new[] { x }) })).ToArray();
                        break;
                    case 3:
                             keyNames = keyNames.OrderByDescending(x => avgTicks.Invoke(data, new[] { invoker.Invoke(func, new[] { x }) })).ToArray();
                        break;
                    case 4:
                            keyNames = keyNames.OrderByDescending(x => startCount.Invoke(data, new[] { invoker.Invoke(func, new[] { x }) })).ToArray();
                        break;
                }
                ControlGrid.DrawGenericGrid((items, index, style, options) =>
                {
                    var value = items[index];
                    var selected = GUILayout.Toggle(this.selectedIndex == index, value, style);
                    if (selected)
                    {
                        this.selectedIndex = index;
                        var key = invoker.Invoke(func, new[] { value }); 
                        this.performanceData = string.Format("{0}\r\nTotal: {1}ms ({4} ticks)\r\nAverage: {2}ms ({5} ticks)\r\nCount: {3}\r\n", value,
                            totalMilli.Invoke(data, new[] { key }),
                            avgMilli.Invoke(data, new[] { key }),
                            startCount.Invoke(data, new[] { key }),
                            totalTicks.Invoke(data, new[] { key }),
                            avgTicks.Invoke(data, new[] { key }));
                    }
                    return value;
                }, keyNames, 1, GUI.skin.button);
            }
        }
