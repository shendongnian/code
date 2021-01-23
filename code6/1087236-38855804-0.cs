    using System.Collections.Generic;
    using Ranet.Olap.Core.Data;
    using Ranet.Olap.Core.Managers;
    using Ranet.Olap.Core.Types;
    using Ranet.Olap.Core.Wrappers;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			startWork();
    		}
    
    		public static void startWork()
    		{
    
    			var mdx = new QueryBuilderParameters
    			{
    				CubeName = "[Adventure Works]",
    				SubCube = "",
    				MdxDesignerSetting = new MDXDesignerSettingWrapper(),
    				CalculatedMembers = new List<CalcMemberInfo>(),
    				CalculatedNamedSets = new List<CalculatedNamedSetInfo>(),
    				AreaWrappersFilter = new List<AreaItemWrapper>(),
    				AreaWrappersColumns = new List<AreaItemWrapper>(),
    				AreaWrappersRows = new List<AreaItemWrapper>(),
    				AreaWrappersData = new List<AreaItemWrapper>()
    			};
    
    			//define parameters
    			mdx.MdxDesignerSetting.HideEmptyColumns = false;
    			mdx.MdxDesignerSetting.HideEmptyRows = false;
    			mdx.MdxDesignerSetting.UseVisualTotals = false;
    			mdx.MdxDesignerSetting.SubsetCount = 0;
    
    			var itemCol1 = new Hierarchy_AreaItemWrapper
    			{
    				AreaItemType = AreaItemWrapperType.Hierarchy_AreaItemWrapper,
    				UniqueName = "[Customer].[Customer Geography]"
    			};
    			mdx.AreaWrappersColumns.Add(itemCol1);
    
    			var itemRow1 = new Hierarchy_AreaItemWrapper
    			{
    				AreaItemType = AreaItemWrapperType.Hierarchy_AreaItemWrapper,
    				UniqueName = "[Date].[Calendar]"
    			};
    			mdx.AreaWrappersRows.Add(itemRow1);
    
    			var itemData1 = new Measure_AreaItemWrapper();
    			itemData1.AreaItemType = AreaItemWrapperType.Measure_AreaItemWrapper;
    			itemData1.UniqueName = "[Measures].[Internet Order Count]";
    			mdx.AreaWrappersData.Add(itemData1);
    
    			string query = MdxQueryBuilder.Default.BuildQuery(mdx, null);
    
    		}
    	}
    }
