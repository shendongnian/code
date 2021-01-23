    //-----------------------------------------------------------------------
    // <copyright file="ExcelDataGridCellColorConverter.cs" company="best Research">
    //     Copyright (c) best Research. All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------
    
    namespace myTool.Utils
    {
        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Globalization;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Controls;
        using System.Windows.Data;
        using System.Windows.Media;
    
        /// <summary>
        /// Used to convert a cell to its final color. It determines this based on both row and column.
        /// </summary>
       public class ExcelDataGridCellColorConverter : IMultiValueConverter
        {
            /// <summary>
            /// Used to convert a cell to its final color. It determines this based on both row and column.
            /// </summary>
            /// <param name="values">the parameter array</param>
            /// <param name="targetType">The target type.</param>
            /// <param name="parameter">the parameter.</param>
            /// <param name="culture">the culture.</param>
            /// <returns>
            /// A Brush
            /// </returns>
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values[1] is DataRow)
                {
                    var cell = (DataGridCell)values[0];
                    var row = (DataRow)values[1];
                    var columnName = cell.Column.SortMemberPath;
                    var table = row.Table;
    
                    // this is used because there is a bug in WPF which causes a removed  datarow to be "seen". This happens when deleting empty rows. The Key "lock" should be added by the deleting method and then removed afterwards.
                    if (table.ExtendedProperties.Contains("lock"))
                    {
                        return Brushes.Gainsboro;
                    }
    
                    var colValue = table.Rows[table.Rows.Count - 1][columnName];
                    var rowValue = row[Properties.Resources.ColorColumnName];
                    var colorColValue = (Enums.RowState)Enum.Parse(typeof(Enums.RowState), colValue.ToString(), true);
                    var colorRowValue = (Enums.RowState)Enum.Parse(typeof(Enums.RowState), rowValue.ToString(), true);
    
                    if (colorColValue == Enums.RowState.IsIncluded && colorRowValue == Enums.RowState.IsIncluded)
                    {
                        return Brushes.LightGreen;
                    }
                    else if (colorRowValue == Enums.RowState.HeaderRow)
                    {
                        return Brushes.Gainsboro;
                    }
                    else
                    { 
                        return Brushes.LightSalmon;
                    }
                }
    
                return Brushes.Blue;
            }
    
            /// <summary>
            /// Not used
            /// </summary>
            /// <param name="value">the parameter</param>
            /// <param name="targetTypes">The target types.</param>
            /// <param name="parameter">the parameter.</param>
            /// <param name="culture">the culture.</param>
            /// <returns>
            /// A Brush
            /// </returns>
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new System.NotImplementedException();
            }
        }
    }
