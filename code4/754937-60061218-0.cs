DateTime birthDate = DateTime.Parse(dob_main.Text);
if (IsAgeLessThan18Years(birthDate))
{
    MessageBox.Show("Invalid Birth Day");
}
bool IsAgeLessThan18Years(DateTime birthDate)
        {
            if (DateTime.Now.Year - birthDate.Year > 18)
            {
                return false;
            }
            else if (DateTime.Now.Year - birthDate.Year < 18)
            {
                return true;
            }
            else //if (DateTime.Now.Year - birthDate.Year == 18)
            {
                if (birthDate.DayOfYear < DateTime.Now.DayOfYear)
                {
                    return false;
                }
                else if (birthDate.DayOfYear > DateTime.Now.DayOfYear)
                {
                    return true;
                }
                else //if (birthDate.DayOfYear == DateTime.Now.DayOfYear)
                {
                    return false;
                }
            }
        }
