    private static CellValue EvaluateFormulaCellValue(XSSFWorkbook wb, ICell cell)
            {
                 WorkbookEvaluator _bookEvaluator = null;
                _bookEvaluator = new WorkbookEvaluator(XSSFEvaluationWorkbook.Create(wb), null, null);
                // XSSFFormulaEvaluator.EvaluateAllFormulaCells(wb);
                ValueEval eval = _bookEvaluator.Evaluate(new XSSFEvaluationCell((XSSFCell)cell));
                if (eval is NumberEval)
                {
                    NumberEval ne = (NumberEval)eval;
                    return new NPOI.SS.UserModel.CellValue(ne.NumberValue);
                }
                if (eval is BoolEval)
                {
                    BoolEval be = (BoolEval)eval;
                    return NPOI.SS.UserModel.CellValue.ValueOf(be.BooleanValue);
                }
                if (eval is StringEval)
                {
                    StringEval ne = (StringEval)eval;
                    return new NPOI.SS.UserModel.CellValue(ne.StringValue);
                }
                if (eval is ErrorEval)
                {
                    return NPOI.SS.UserModel.CellValue.GetError(((ErrorEval)eval).ErrorCode);
                }
                throw new InvalidOperationException("Unexpected eval class (" + eval.GetType().Name + ")");
            }
